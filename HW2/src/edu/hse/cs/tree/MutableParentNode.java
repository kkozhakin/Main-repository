package edu.hse.cs.tree;

import java.util.*;

/**
 * Class MutableParentNode.
 * @param <T> - the type of wrapped object
 */
public class MutableParentNode<T>
        extends
        AbstractTreeNode<T>
        implements
        IChild<T>,
        IParent<T> {

    /** parent value*/
    private IParent<T> parent;
    /** children set*/
    private Set<? extends IChild<T>> children;

    /**
     * Constructor - create new object with value.
     * @param object value
     */
    public MutableParentNode(T object) {
        super(object);
        this.parent = null;
        this.children = null;
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

    /** @return children set view */
    @Override
    public Set<? extends IChild<T>> getChildren() { return children; }

    /**
     * Set new children set.
     * @param newValue children
     */
    public void setChildren(Set<? extends IChild<T>> newValue) {
        if (newValue != null) {
            @SuppressWarnings("unchecked")
            AbstractTreeNode<T>[] childrenarr = new AbstractTreeNode[newValue.size()];
            newValue.toArray(childrenarr);
            for (AbstractTreeNode<T> tAbstractTreeNode : childrenarr) {
                if (tAbstractTreeNode instanceof ImmutableParentNode) {
                    MutableParentNode<T> node = new MutableParentNode<>(tAbstractTreeNode.getObject());
                    node.setParent(this);
                    node.setChildren(((ImmutableParentNode<T>) tAbstractTreeNode).getChildren());
                    addChild(node);
                }
                else if (tAbstractTreeNode instanceof ImmutableChildNode) {
                    MutableChildNode<T> node = new MutableChildNode<>(tAbstractTreeNode.getObject());
                    node.setParent(this);
                    addChild(node);
                }
                else if (tAbstractTreeNode instanceof IChild)
                    addChild(tAbstractTreeNode);
            }
        }
    }

    /** @return descendants collection view */
    @Override
    @SuppressWarnings("unchecked")
    public Collection<? extends IChild<T>> getAllDescendants() {
        Collection<IChild<T>> descendants = new HashSet<>();
        if (children != null) {
            AbstractTreeNode<T>[] childrenarr = new AbstractTreeNode[children.size()];
            children.toArray(childrenarr);
            for (AbstractTreeNode<T> tAbstractTreeNode : childrenarr) {
                descendants.add((IChild<T>) tAbstractTreeNode);
                if (tAbstractTreeNode instanceof MutableParentNode)
                    try {
                        descendants.addAll(((MutableParentNode<T>) tAbstractTreeNode).getAllDescendants());
                    }
                    catch (NullPointerException ignored) {}
            }
        }
        return descendants;
    }

    /**
     * Find object in children set.
     * @param childValue value
     * @return contains or not
     * @see MutableParentNode#containsDescendants(Object)
     */
    @Override
    public boolean contains(T childValue) {
        @SuppressWarnings("unchecked")
        AbstractTreeNode<T>[] childrenarr = new AbstractTreeNode[children.size()];
        children.toArray(childrenarr);
        for (AbstractTreeNode<T> tAbstractTreeNode : childrenarr)
            if (tAbstractTreeNode.getObject().equals(childValue))
                return true;
        return false;
    }

    /**
     * Find object in descendants collection.
     * @param childValue value
     * @return contains or not
     * @see MutableParentNode#contains(Object)
     */
    @Override
    public boolean containsDescendants(T childValue) {
        @SuppressWarnings("unchecked")
        AbstractTreeNode<T>[] childrenarr = new AbstractTreeNode[children.size()];
        children.toArray(childrenarr);
        for (AbstractTreeNode<T> tAbstractTreeNode : childrenarr) {
            if (tAbstractTreeNode.getObject().equals(childValue))
                return true;
            if (tAbstractTreeNode instanceof MutableParentNode)
                if (((MutableParentNode<T>) tAbstractTreeNode).containsDescendants(childValue))
                    return true;
        }
        return false;
    }

    /**
     * Removes the first child of this node that has the specified value.
     * @param childValue the value of the child to be removed
     * @return the child removed, or null if the child with the given value was not found
     */
    public AbstractTreeNode<T> removeChildByValue(T childValue) {
        @SuppressWarnings("unchecked")
        AbstractTreeNode<T>[] childrenarr = new AbstractTreeNode[children.size()];
        children.toArray(childrenarr);
        for (AbstractTreeNode<T> tAbstractTreeNode : childrenarr)
            if (tAbstractTreeNode.getObject().equals(childValue)){
                children.remove(tAbstractTreeNode);
                return tAbstractTreeNode;
            }
        return null;
    }

    /**
     * Removes this node descendants having the specified value.
     * @param childValue the value of the descendant of this node that must be removed
     * @return true if at least one descendant was removed, false - otherwise
     */
    public boolean removeDescendantsByValue(T childValue) {
        @SuppressWarnings("unchecked")
        AbstractTreeNode<T>[] childrenarr = new AbstractTreeNode[children.size()];
        children.toArray(childrenarr);
        for (AbstractTreeNode<T> tAbstractTreeNode : childrenarr) {
            if (tAbstractTreeNode.getObject().equals(childValue)) {
                children.remove(tAbstractTreeNode);
                return true;
            }
            if (tAbstractTreeNode instanceof MutableParentNode)
                if (((MutableParentNode<T>) tAbstractTreeNode).containsDescendants(childValue)) {
                    ((MutableParentNode<T>) tAbstractTreeNode).removeDescendantsByValue(childValue);
                    return true;
                }
        }
        return false;
    }

    /**
     * Adds child to the node.
     * @param node node to be added
     */
    @SuppressWarnings("unchecked")
    public void addChild(AbstractTreeNode<T> node) {
        Set<IChild<T>> Children;
        if (this.children != null)
            Children = new HashSet<>(children.size() + 1);
        else
            Children = new HashSet<>(1);
        if (node instanceof MutableParentNode || node instanceof MutableChildNode)
            Children.add((IChild) node);
        else
            throw new IllegalArgumentException("Node must implement IChild and Mutable");
        if (children != null)
            Children.addAll(children);
        this.children = Children;
    }

    /**
     * Class object string view.
     * @param indent indent
     * @return string format
     */
    @Override
    public String toStringForm(String indent) {
        StringBuilder s = new StringBuilder(indent + "MutableParentNode(" + getObject().toString() + ")\n");
        @SuppressWarnings("unchecked")
        AbstractTreeNode<T>[] childrenarr = new AbstractTreeNode[children.size()];
        children.toArray(childrenarr);
        for (AbstractTreeNode<T> tAbstractTreeNode : childrenarr)
            s.append(tAbstractTreeNode.toStringForm("    " + indent));
        return s.toString();
    }
}
