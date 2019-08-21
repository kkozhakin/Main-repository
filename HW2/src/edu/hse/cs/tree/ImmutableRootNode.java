package edu.hse.cs.tree;

import java.util.Collection;
import java.util.HashSet;
import java.util.Set;

/**
 * Class ImmutableRootNode.
 * @param <T> - the type of wrapped object
 */
public class ImmutableRootNode<T>
        extends
        AbstractTreeNode<T>
        implements
        IParent<T> {
    /** final children set*/
    private final Set<? extends IChild<T>> children;

    /**
     * Constructor - create new object with value and children.
     * @param object value
     * @param children collection of children
     * @see ImmutableRootNode#ImmutableRootNode(MutableRootNode)
     */
    public ImmutableRootNode(T object, Set<? extends IChild<T>> children) {
        super(object);
        if (children != null) {
            @SuppressWarnings("unchecked")
            AbstractTreeNode<T>[] childrenarr = new AbstractTreeNode[children.size()];
            children.toArray(childrenarr);
            Set<IChild<T>> Children = new HashSet<>(children.size());
            for (AbstractTreeNode<T> tAbstractTreeNode : childrenarr) {
                if (tAbstractTreeNode instanceof MutableParentNode)
                    Children.add(new ImmutableParentNode<>(tAbstractTreeNode.getObject(),
                            this, ((MutableParentNode<T>) tAbstractTreeNode).getChildren()));
                else if (tAbstractTreeNode instanceof MutableChildNode)
                    Children.add(new ImmutableChildNode<>(tAbstractTreeNode.getObject(), this));
                else if (tAbstractTreeNode instanceof IChild)
                    Children.add((IChild<T>) tAbstractTreeNode);
            }
            this.children = Children;
        } else
            this.children = null;
    }

    /**
     * Constructor - create new object from {@link MutableRootNode}.
     * @param source sourse node
     * @see ImmutableRootNode#ImmutableRootNode(Object, Set)
     */
    public ImmutableRootNode(MutableRootNode<T> source) {
        super(source.getObject());
        Collection<? extends IChild<T>> child = source.getChildren();
        if (child != null) {
            @SuppressWarnings("unchecked")
            AbstractTreeNode<T>[] childrenarr = new AbstractTreeNode[child.size()];
            child.toArray(childrenarr);
            Set<IChild<T>> Children = new HashSet<>(child.size());
            for (AbstractTreeNode<T> tAbstractTreeNode : childrenarr) {
                if (tAbstractTreeNode instanceof MutableParentNode)
                    Children.add(new ImmutableParentNode<>(tAbstractTreeNode.getObject(),
                            this, ((MutableParentNode<T>) tAbstractTreeNode).getChildren()));
                else if (tAbstractTreeNode instanceof MutableChildNode)
                    Children.add(new ImmutableChildNode<>(tAbstractTreeNode.getObject(), this));
                else if (tAbstractTreeNode instanceof IChild)
                    Children.add((IChild<T>) tAbstractTreeNode);
            }
            this.children = Children;
        } else
            this.children = null;
    }

    /** @return children set view */
    @Override
    public Set<? extends IChild<T>> getChildren() { return children; }

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
                if (tAbstractTreeNode instanceof ImmutableParentNode)
                    try {
                        descendants.addAll(((ImmutableParentNode<T>) tAbstractTreeNode).getAllDescendants());
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
     * @see ImmutableRootNode#containsDescendants(Object)
     */
    @Override
    public boolean contains(T childValue) {
        if (children != null) {
            @SuppressWarnings("unchecked")
            AbstractTreeNode<T>[] childrenarr = new AbstractTreeNode[children.size()];
            children.toArray(childrenarr);
            for (AbstractTreeNode<T> tAbstractTreeNode : childrenarr)
                if (tAbstractTreeNode.getObject().equals(childValue))
                    return true;
        }
        return false;
    }

    /**
     * Find object in descendants collection.
     * @param childValue value
     * @return contains or not
     * @see ImmutableRootNode#contains(Object)
     */
    @Override
    public boolean containsDescendants(T childValue) {
        if (children != null) {
            @SuppressWarnings("unchecked")
            AbstractTreeNode<T>[] childrenarr = new AbstractTreeNode[children.size()];
            children.toArray(childrenarr);
            for (AbstractTreeNode<T> tAbstractTreeNode : childrenarr) {
                if (tAbstractTreeNode.getObject().equals(childValue))
                    return true;
                if (tAbstractTreeNode instanceof ImmutableParentNode)
                    if (((ImmutableParentNode<T>) tAbstractTreeNode).containsDescendants(childValue))
                        return true;
            }
        }
        return false;
    }

    /**
     * Class object string view.
     * @param indent indent
     * @return string format
     */
    @Override
    public String toStringForm(String indent) {
        StringBuilder s = new StringBuilder(indent + "ImmutableRootNode(" + getObject().toString() + ")\n");
        @SuppressWarnings("unchecked")
        AbstractTreeNode<T>[] childrenarr = new AbstractTreeNode[children.size()];
        children.toArray(childrenarr);
        for (AbstractTreeNode<T> tAbstractTreeNode : childrenarr)
            s.append(tAbstractTreeNode.toStringForm("    " + indent));
        return s.toString();
    }
}
