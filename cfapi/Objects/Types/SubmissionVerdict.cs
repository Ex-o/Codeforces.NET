namespace cfapi.Objects
{
    public enum SubmissionVerdict
    {
        FAILED,
        OK,
        PARTIAL,
        COMPILATION_ERROR,
        RUNTIME_ERROR,
        WRONG_ANSWER,
        PRESENTATION_ERROR,
        TIME_LIMIT_EXCEEDED,
        MEMORY_LIMIT_EXCEEDED,
        IDLENESS_LIMIT_EXCEEDED,
        SECURITY_VIOLATED,
        CRASHED,
        INPUT_PREPARATION_CRASHED,
        CHALLENGED,
        SKIPPED,
        TESTING,
        REJECTED
    }
}