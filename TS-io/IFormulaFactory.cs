namespace Ts.IO {

    /// <summary>
    /// Provides functionality to convert possible representations of formula to it's labeled ordered tree representation
    /// </summary>
    public interface IFormulaFactory {

        Formula Parse(string unparsedFormula);
    }
}
