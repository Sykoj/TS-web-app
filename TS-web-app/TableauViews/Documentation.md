# Layout of tableau solution tree

## View tree
- Each implementation of tableau view (text, svg) defines it's node type
  implementing ILayoutable
- Each implementation of tableau view (text, svg) defines factory implementing
  IViewFactory, which provides nodes mentioned above based on node of tableau solution tree
- View tree is created by transformation of tableau solution tree using the factory

## Layout processor
- Accepts view tree
- Accepts option ILayoutOptions with layout parameters such as width or height between nodes or root's position
- At first, it computes the total width and height for each subtree in view tree
- Next, it alignes the nodes in context of it's childs and subtree
  - Each direct path with no branches forking the path has axis
    - In case of branch forking, new offsets for childs are calculated from width of the subtree
and sizes of the child nodes
    - In case of no forking, child has the same offset
  - Algorithm calculates position of node (left lower corner of node)
from the offset, and node sizes