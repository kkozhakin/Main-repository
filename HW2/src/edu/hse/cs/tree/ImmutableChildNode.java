package edu.hse.cs.tree;

/**
 * Class ImmutableChildNode.
 * @param <T> - the type of wrapped object
 */
public class ImmutableChildNode<T>
        extends
        AbstractTreeNode<T>
        implements
        IChild<T> {

    /** final parent value*/
    private final IParent<T> parent;

    /**
     * Constructor - create new object with value and parent.
     * @param object value
     * @param parent parent node
     */
    ImmutableChildNode(T object, IParent<T> parent) {
        super(object);
        if (parent instanceof MutableRootNode || parent instanceof MutableParentNode
                || parent instanceof MutableChildNode)
            throw new IllegalArgumentException("Parent must be Immutable");
        this.parent = parent;
    }

    /** @return parent view */
    public IParent<T> getParent() {
        return parent;
    }

    /**
     * Class object string view.
     * @param indent indent
     * @return string format
     */
    @Override
    public String toStringForm(String indent) {
        return indent + "ImmutableChildNode(" + getObject().toString() + ")\n";
    }
}
