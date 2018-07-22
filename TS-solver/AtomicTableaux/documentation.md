### Atomic tableaux

- Each atomic tableau has specific formula as it's root
  - The type of the formula determines the type of the atomic tableau
- Atomic tableau accepts and develops branch into new branches  
  - Each root's formula type and truth label creates specific rule
- In solver algorithm, atomic tableau is used as flow control
  - First, branch receives formula and truth label 
  - Branch creates atomic tableau
  - Branch accepts from the atomic tableau new solution tree node
  - Branch is forked or modified depending on atomic tableau behaviour 