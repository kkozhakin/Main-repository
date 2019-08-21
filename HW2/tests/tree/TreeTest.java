package tree;

import edu.hse.cs.tree.*;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

import java.util.Collection;
import java.util.HashSet;
import java.util.Set;

public class TreeTest {

    @Test
    public void testGetChildren(){
        MutableRootNode<String> root = populateTree();
        Assertions.assertEquals(root.getChildren().size(), 3);
    }

    @Test
    public void testGetAllDescendants(){
        MutableRootNode<String> root = populateTree();
        Assertions.assertEquals(root.getAllDescendants().size(), 6);
    }

    @Test
    public void testAddChild(){
        MutableRootNode<String> root = populateTree();
        root.addChild(new MutableParentNode<>("Parent2"));
        root.addChild(new MutableChildNode<>("Child1"));
        Assertions.assertEquals(root.getChildren().size(), 5);
        Assertions.assertThrows(IllegalArgumentException.class, ()-> root.addChild(new MutableRootNode<>("Root1")));
        Assertions.assertThrows(IllegalArgumentException.class, ()-> root.addChild(new ImmutableParentNode<>("ImParent", root, null)));
    }

    @Test
    public void testContains(){
        MutableRootNode<String> root = populateTree();
        Assertions.assertTrue(root.contains("Parent1"));
        Assertions.assertFalse(root.contains("Child00"));
        Assertions.assertTrue(root.containsDescendants("Child00"));
        Assertions.assertFalse(root.containsDescendants("Parent2"));
    }

    @Test
    public void testRemove(){
        MutableRootNode<String> root = populateTree();
        Assertions.assertTrue(root.removeDescendantsByValue("Child00"));
        Assertions.assertFalse(root.removeDescendantsByValue("Child00"));
        Assertions.assertEquals(root.getAllDescendants().size(), 5);

        Assertions.assertNull(root.removeChildByValue("Parent2"));
        root.removeChildByValue("Parent0");
        Assertions.assertEquals(root.getChildren().size(),2);
    }

    @Test
    public void testMutableImmutable(){
        MutableRootNode<String> root = populateTree();
        ImmutableRootNode<String> root0 = new ImmutableRootNode<>(root);
        MutableRootNode<String> root1 = new MutableRootNode<>(root0);
        Assertions.assertEquals(root1.getChildren().size(),root.getChildren().size());
        Assertions.assertEquals(root1.containsDescendants("Child01"),root.containsDescendants("Child01"));
        Assertions.assertEquals(root1.getClass(), root.getClass());
        Assertions.assertEquals(root.getAllDescendants().size(), root0.getAllDescendants().size());

        Collection<? extends IChild<String>> children = root.getAllDescendants();
        @SuppressWarnings("unchecked")
        AbstractTreeNode<String>[] childrenarr = new AbstractTreeNode[children.size()];
        children.toArray(childrenarr);
        for (AbstractTreeNode<String> treeNode : childrenarr)
            Assertions.assertTrue(root0.containsDescendants(treeNode.getObject()));
    }

    @Test
    public void testTreeImporter(){
        MutableRootNode<String> root = populateTree();
        MutableRootNode<String> root1 =TreeImporter.importStringMutableTree("MutableRootNode(Root)\n" +
                "    MutableChildNode(Child0)\n" +
                "    MutableParentNode(Parent0)\n" +
                "        MutableChildNode(Child00)\n" +
                "        MutableChildNode(Child01)\n" +
                "    MutableParentNode(Parent1)\n" +
                "        MutableChildNode(Child10)");
        Assertions.assertEquals(root1.getChildren().size(),root.getChildren().size());
        Assertions.assertEquals(root.getAllDescendants().size(), root1.getAllDescendants().size());

        Collection<? extends IChild<String>> children = root.getAllDescendants();
        @SuppressWarnings("unchecked")
        AbstractTreeNode<String>[] childrenarr = new AbstractTreeNode[children.size()];
        children.toArray(childrenarr);
        for (AbstractTreeNode<String> treeNode : childrenarr)
            Assertions.assertTrue(root1.containsDescendants(treeNode.getObject()));

        Assertions.assertThrows(ExceptionInInitializerError.class, ()-> TreeImporter.importStringMutableTree("Root(MutableRootNode)"));
        Assertions.assertThrows(ExceptionInInitializerError.class, ()-> TreeImporter.importDoubleMutableTree("Root(MutableRootNode)"));
        Assertions.assertThrows(ExceptionInInitializerError.class, ()-> TreeImporter.importIntegerMutableTree("MutableRootNode(2.4)\n" +
                "    MutableChildNode(0.111)\n" +
                "    MutableParentNode(1.222)\n" +
                "        MutableChildNode(10.33)\n" +
                "        MutableChildNode(11.467)\n" +
                "    MutableParentNode(2.69)\n" +
                "        MutableChildNode(20.0)"));
        Assertions.assertDoesNotThrow(()-> TreeImporter.importIntegerMutableTree("MutableRootNode(2)\n" +
                "    MutableChildNode(0)\n" +
                "    MutableParentNode(1)\n" +
                "        MutableChildNode(10)\n" +
                "        MutableChildNode(11)\n" +
                "    MutableParentNode(2)\n" +
                "        MutableChildNode(20)"));
        Assertions.assertDoesNotThrow(()-> TreeImporter.importDoubleMutableTree("MutableRootNode(2.4)\n" +
                "    MutableChildNode(0.111)\n" +
                "    MutableParentNode(1.222)\n" +
                "        MutableChildNode(10.33)\n" +
                "        MutableChildNode(11.467)\n" +
                "    MutableParentNode(2.69)\n" +
                "        MutableChildNode(20.0)"));
    }

    private static MutableRootNode<String> populateTree(){
        MutableRootNode<String> root = new MutableRootNode<>("Root");

        MutableParentNode<String> parent0 = new MutableParentNode<>("Parent0");
        MutableParentNode<String> parent1 = new MutableParentNode<>("Parent1");

        MutableChildNode<String> child0 = new MutableChildNode<>("Child0");
        MutableChildNode<String> child00 = new MutableChildNode<>("Child00");
        MutableChildNode<String> child01 = new MutableChildNode<>("Child01");
        MutableChildNode<String> child10 = new MutableChildNode<>("Child10");

        Set<IChild<String>> rootChildren = new HashSet<>(3);
        rootChildren.add(parent0);
        rootChildren.add(parent1);
        rootChildren.add(child0);
        root.setChildren(rootChildren);
        parent0.setParent(root);
        parent1.setParent(root);
        child0.setParent(root);

        Set<IChild<String>> parent0Children = new HashSet<>(2);
        parent0Children.add(child00);
        parent0Children.add(child01);
        parent0.setChildren(parent0Children);
        child00.setParent(parent0);
        child01.setParent(parent0);

        Set<IChild<String>> parent1Children = new HashSet<>(1);
        parent1Children.add(child10);
        parent1.setChildren(parent1Children);
        child10.setParent(parent1);

        return root;
    }

}
