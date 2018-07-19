namespace Ts.IO {
    
    public sealed class CompletionClosure : Formula {

        public override bool Equals(object obj) {
            return obj is CompletionClosure;
        }

        public override int GetHashCode() {
            return 42;
        }
    }
}
