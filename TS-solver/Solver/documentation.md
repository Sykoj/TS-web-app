### Tableau solver algorithm

#### Input
- Root (from which is tableau developed) as pair of formula and truth label
- Sequence of 
  theory axioms as pairs of formula and truth label

#### Branches
- Algorithm creates solution tree that consists of tableau branches
- Algorithm has queue of branches
- Each branch has tree's node that is currently at top of the branch
- Each branch has queue of formulas (as they are added during algorithm for further use)
and queue of axioms from the input

#### Algorithm

- Initialization
  - Creates new branch and adds root formula to formula queue, axioms to axiom queue
  - Adds branch to the branch queue

- (step 1) Gets first branch from the branch queue if queue is not empty
- Provide new formula for the branch:
  - Removes the first formula from formula queue and creates atomic tableau from the formula
  - If there is no formula, removes one from axiom queue    
  - If formula is a variable and there is the same variable formula with different truth label, branch is finished as contradictionary
  - If there is no formula, branch is finished as nonctradictionary

- Branch creates from the formula atomic tableau
- Branch accepts new tree node from atomic tableau and adds the node to it's top
- Branch accepts new branches from atomic tableau and adds them to the branch queue
    - Atomic tableau already added new formulas to the branch's formula queue
- Go to step 1

#### Output
- Solution tree