package edu.hse.cs.tree;

/**
 * Class MutableChildNode.
 * @param <T> - the type of wrapped object
 */
public class MutableChildNode<T>
        extends
        AbstractTreeNode<T>
        implements
        IChild<T> {

    /** parent value*/
    private IParent<T> parent;

    /**
     * Constructor - create new object with value.
     * @param object value
     */
    public MutableChildNode(T object) {
        super(object);
    }

    /** @return parent view */
    @Override
    public IParent<T> getParent() {
        return parent;
    }

    /**
     * Set new parent value.
     * @param newValue parent
     */
    public void setParent(IParent<T> newValue) {
        if (newValue instanceof ImmutableRootNode || newValue instanceof ImmutableParentNode
                || newValue instanceof ImmutableChildNode)
            throw new IllegalArgumentException("Parent must be Mutable");
        this.parent = newValue;
    }

    /**
     * Class object string view.
     * @param indent indent
     * @return string format
     */
    @Override
    public String toStringForm(String indent) {
        return indent + "MutableChildNode(" + getObject().toString() + ")\n";
    }
}
