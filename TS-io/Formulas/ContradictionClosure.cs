namespace Ts.IO {
    
    public sealed class ContradictionClosure : Formula {

        public override bool Equals(object obj) {
            return obj is ContradictionClosure;
        }

        public override int GetHashCode() {
            return 42;
        }
    }
}
