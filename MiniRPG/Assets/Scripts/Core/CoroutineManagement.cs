using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class CoroutineManagement : SingletonBehavior<CoroutineManagement>
{
    #region Coroutines

    // 코루틴 상태
    private enum CoroutineState
    {
        Running,
        Finished
    }

    // 코루틴 정보
    private class CoroutineInfo
    {
        public Coroutine Coroutine;
        public CoroutineState State;
    }

    private readonly Dictionary<IEnumerator, CoroutineInfo> _coroutines =
        new Dictionary<IEnumerator, CoroutineInfo>();
    
    // Exception Event => 예외에 대한 이벤트
    public event Action<Exception> OnCoroutineException;

    #endregion



    #region Behavior

    private void Awake()
    {
        // 기본 예외 처리 핸들러 구독
        OnCoroutineException += HandleCoroutineException;
    }

    protected override void OnDestroy()
    {
        // 구독 해제
        // 싱글톤 인스턴스가 아직 존재하는지 확인
        if (Instance != null)
        {
            OnCoroutineException -= HandleCoroutineException;
        }
        
        base.OnDestroy();
    }

    #endregion



    #region Managed Coroutine

    public Coroutine StartManagedCoroutine(IEnumerator coroutine, float delaySeconds = 0f, Action onComplete = null)
    {
        if (delaySeconds < 0) throw new ArgumentException("DelaySeconds cannot be negative.", nameof(delaySeconds));

        if (_coroutines.TryGetValue(coroutine, out var existingCoroutine) &&
            existingCoroutine.State != CoroutineState.Finished) return existingCoroutine.Coroutine;

        var coroutineInstance = StartCoroutine(
            delaySeconds > 0 
                ? DelayedStartCoroutine(coroutine, onComplete, delaySeconds) 
                : WrapperCoroutine(coroutine, onComplete, 0f)
        );

        _coroutines[coroutine] = new CoroutineInfo { Coroutine = coroutineInstance, State = CoroutineState.Running };

        return coroutineInstance;
    }

    public void StopManagedCoroutine(IEnumerator coroutine)
    {
        if (_coroutines.TryGetValue(coroutine, out var runningCoroutine) && runningCoroutine.State == CoroutineState.Running)
        {
            StopCoroutine(runningCoroutine.Coroutine);
            runningCoroutine.State = CoroutineState.Finished;
        }

        _coroutines.Remove(coroutine);
    }

    #endregion

    
    
    #region Getter

    /// <summary>
    /// # 실행되고 있는 코루틴들을 반환
    /// </summary>
    public List<IEnumerator> GetRunningCoroutines()
    {
        return (from entry in _coroutines where entry.Value.State == CoroutineState.Running select entry.Key).ToList();
    }

    #endregion

    
    
    #region Coroutine Utils
    
    private IEnumerator DelayedStartCoroutine(IEnumerator coroutine, Action onComplete, float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        yield return StartCoroutine(WrapperCoroutine(coroutine, onComplete, delaySeconds));
    }

    private IEnumerator WrapperCoroutine(IEnumerator coroutine, Action onComplete, float delaySeconds)
    {
        if (delaySeconds > 0) yield return new WaitForSeconds(delaySeconds);

        yield return StartCoroutine(RunCoroutineWithExceptionHandling(coroutine));

        onComplete?.Invoke();

        if (!_coroutines.TryGetValue(coroutine, out var info)) yield break;
        
        info.State = CoroutineState.Finished;
        _coroutines.Remove(coroutine); // 메모리 관리를 위해 코루틴 제거
    }

    private IEnumerator RunCoroutineWithExceptionHandling(IEnumerator coroutine)
    {
        while (true)
        {
            object current;
            try
            {
                if (!coroutine.MoveNext())
                {
                    yield break;
                }
                current = coroutine.Current;
            }
            catch (Exception exception)
            {
                OnCoroutineException?.Invoke(exception);
                yield break;
            }

            yield return current;
        }
    }

    #endregion
    
    
    
    #region Basic Exception Handler
    
    private void HandleCoroutineException(Exception exception)
    {
        // 예외 발생 시 기본 로그 처리
        Debug.LogError($"Coroutine exception: {exception}");
    }
    
    #endregion
}
