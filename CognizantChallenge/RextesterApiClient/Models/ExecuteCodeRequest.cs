namespace CognizantChallenge.RextesterApiClient.Models
{
    public class ExecuteCodeRequest
    {
        public string LanguageChoice { get; set; } = "1";
        public string Program { get; set; }
        public string Input { get; set; }
        public string CompilerArgs { get; set; }
    }
}
