### Parser input
- Parser accepts string representing prepositional formula defined by inductive rule:
     - Each variable is lower case alphabetical character [a-z]
     is formula
     - If *F* and *G* are formulas, then<br>
     (NOT *G*) - represents negation<br>
     (*F* AND *G*) - represents conjunction<br>
     (*F* OR *G*) - represents disjunction<br>
     (*F* IMP *G*) - represents implication<br>
     (*F* EKV *G*) - represents equivalence
      <br>are also formulas
     - Each formula is created by those mentioned rules
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
     


### Parser algorithm

- Formula represented by string is root of the labeled ordered tree
- By reading the string from the left, parser detects childs of this formula in the ordered tree - subformulas, junctions (for example implication) or variables
- Parser remembers starting and ending positions of those childs (in code, they are called tokens) in the string
- By number of detected tokens and their type, parser then decides if those tokens forms valid formula
- If token is of the subformula type, the same procedure is applied on the token's substring to parse it as formula

### Parser output
Parser returns the labeled ordered tree of the formula