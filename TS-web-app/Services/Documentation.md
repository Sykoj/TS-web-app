# Services


## Conversion service
- Conversion of different types of input into input model for tableau solver

## Event service
- Layer above database context, all operations with database should be accessed in this service

## Form resolver
- Processes input form from HTML and verifies the structure of the form

## TextViewService
- Creates textual visualization of tableau solution tree

## TableauSolutionService
- Provides solver for method of analytic tableaux

## TableauSolutionCategorizer
- Analyzes solution tree and categorizes tableau type based on it's branches