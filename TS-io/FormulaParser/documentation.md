###Parser input
- Parser accepts string representing prepositional formula defined by inductive rule:
     - Each variable is lower case alphabetical character [a-z]
     is formula
     - If <i>F</i> and <i>G</i> are formulas, then<br>
     (NOT <i>G</i>) - represents negation<br>
     (<i>F</i> AND <i>G</i>) - represents conjunction<br>
     (<i>F</i> OR <i>G</i>) - represents disjunction<br>
     (<i>F</i> IMP <i>G</i>) - represents implication<br>
     (<i>F</i> EKV <i>G</i>) - represents equivalence
      <br>are also formulas
     - Each formula is created by those mentioned rules
     - If formula is not ambiguous, parenthesis can be ommited
 - Examples of formulas:<br>
     p IMP q<br>
     p IMP (q IMP p)<br>
     (p IMP (q IMP p))<br>
     (p EKV (NOT (NOT p)))<br>
     (NOT (p OR q)) EKV ((NOT p) AND (NOT q))<br>
     (p IMP q) EKV ((NOT q) IMP (NOT p))<br>
     (p IMP (q IMP r)) IMP ((p IMP q) IMP (p IMP r))<br>
- String representing the formula is not space sensitive,<br>
    whitespaces are removed from the string before parsing
- Parser is case sensitive - junctions must be always uppercase 
     


###Parser algorithm

- Formula represented by string is root of the labeled ordered tree
- By reading the string from the left, parser detects childs of this formula in the ordered tree - subformulas, junctions (for example implication) or variables
- Parser remembers starting and ending positions of those childs (in code, they are called tokens) in the string
- By number of detected tokens and their type, parser then decides if those tokens forms valid formula
- If token is of the subformula type, the same procedure is applied on the token's substring to parse it as formula

###Parser output
Parser returns the labeled ordered tree of the formula