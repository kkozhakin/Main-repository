package edu.hse.cs.tree;

import java.util.Collection;
import java.util.HashSet;
import java.util.Set;

/**
 * Class MutableRootNode.
 * @param <T> - the type of wrapped object
 */
public class MutableRootNode<T>
        extends
        AbstractTreeNode<T>
        implements
        IParent<T> {

    /** children set*/
    private Set<? extends IChild<T>> children;

    /**
     * Constructor - create new object with value.
     * @param object value
     * @see MutableRootNode#MutableRootNode(ImmutableRootNode)
     */
    public MutableRootNode(T object) {
        super(object);
        this.children = null;
    }

    /**
     * Constructor - create new object from {@link ImmutableRootNode}.
     * @param source sourse node
     * @see MutableRootNode#MutableRootNode(Object)
     */
    public MutableRootNode(ImmutableRootNode<T> source) {
        super(source.getObject());
        this.children = null;
        if (source.getChildren() != null) {
            @SuppressWarnings("unchecked")
            AbstractTreeNode<T>[] childrenarr = new AbstractTreeNode[source.getChildren().size()];
            source.getChildren().toArray(childrenarr);
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

    /** @return children set view */
    @Override
    public final Set<? extends IChild<T>> getChildren() { return children; }

    /**
     * Set new children set.
     * @param newValue children
     */
    public final void setChildren(Set<? extends IChild<T>> newValue) {
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
     * @see MutableRootNode#containsDescendants(Object)
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
     * @see MutableRootNode#contains(Object)
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
        StringBuilder s = new StringBuilder(indent + "MutableRootNode(" + getObject().toString() + ")\n");
        @SuppressWarnings("unchecked")
        AbstractTreeNode<T>[] childrenarr = new AbstractTreeNode[children.size()];
        children.toArray(childrenarr);
        for (AbstractTreeNode<T> tAbstractTreeNode : childrenarr)
            s.append(tAbstractTreeNode.toStringForm("    " + indent));
        return s.toString();
    }
}
