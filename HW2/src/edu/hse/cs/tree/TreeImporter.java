package edu.hse.cs.tree;

import java.util.Stack;

/**
 * Class for parse string to Mutable tree.
 */
public class TreeImporter {

    /** Stack for storing parent nodes.*/
    private static Stack<AbstractTreeNode> stack = new Stack<>();

    /**
     * Parse string to string tree.
     * @param input tree in string
     * @return root node
     * @see TreeImporter#importIntegerMutableTree(String)
     * @see TreeImporter#importDoubleMutableTree(String)
     */
    public static <T> MutableRootNode<T> importStringMutableTree(String input) {
        String[] strs = input.split("\n");
        MutableRootNode<String> root = null;
        int y = 0;
        try {
            for (String str : strs) {
                String[] res = Parse(str.toCharArray());
                if (Integer.parseInt(res[0]) == 0 && res[1].equals("MutableRootNode")) {
                    root = new MutableRootNode<>(res[2]);
                    stack.push(root);
                    y = Integer.parseInt(res[0]);
                } else if (Integer.parseInt(res[0]) <= y && res[1].equals("MutableParentNode")) {
                    MutableParentNode<String> par = new MutableParentNode<>(res[2]);
                    stack.pop();
                    AddChild(par);
                    stack.push(par);
                    y = Integer.parseInt(res[0]);
                } else if (Integer.parseInt(res[0]) > y && res[1].equals("MutableParentNode")) {
                    MutableParentNode<String> par = new MutableParentNode<>(res[2]);
                    AddChild(par);
                    stack.push(par);
                    y = Integer.parseInt(res[0]);
                } else if (Integer.parseInt(res[0]) <= y && res[1].equals("MutableChildNode")) {
                    MutableChildNode<String> child = new MutableChildNode<>(res[2]);
                    stack.pop();
                    AddChild(child);
                } else if (Integer.parseInt(res[0]) > y && res[1].equals("MutableChildNode")) {
                    MutableChildNode<String> child = new MutableChildNode<>(res[2]);
                    AddChild(child);
                } else throw new Exception("");
            }
            return (MutableRootNode<T>) root;
        }
        catch (Exception e)
        {
            throw new ExceptionInInitializerError("Wrong format");
        }
    }

    /**
     * Parse string to integer tree.
     * @param input tree in string
     * @return root node
     * @see TreeImporter#importStringMutableTree(String)
     * @see TreeImporter#importDoubleMutableTree(String)
     */
    public static <T> MutableRootNode<T> importIntegerMutableTree(String input) {
        String[] strs = input.split("\n");
        MutableRootNode<Integer> root = null;
        int y = 0;
        try {
            for (String str : strs) {
                String[] res = Parse(str.toCharArray());
                if (Integer.parseInt(res[0]) == 0 && res[1].equals("MutableRootNode")) {
                    root = new MutableRootNode<>(Integer.parseInt(res[2]));
                    stack.push(root);
                } else if (Integer.parseInt(res[0]) <= y && res[1].equals("MutableParentNode")) {
                    MutableParentNode<Integer> par = new MutableParentNode<>(Integer.parseInt(res[2]));
                    stack.pop();
                    AddChild(par);
                    stack.push(par);
                } else if (Integer.parseInt(res[0]) > y && res[1].equals("MutableParentNode")) {
                    MutableParentNode<Integer> par = new MutableParentNode<>(Integer.parseInt(res[2]));
                    AddChild(par);
                    stack.push(par);
                } else if (Integer.parseInt(res[0]) <= y && res[1].equals("MutableChildNode")) {
                    MutableChildNode<Integer> child = new MutableChildNode<>(Integer.parseInt(res[2]));
                    stack.pop();
                    AddChild(child);
                } else if (Integer.parseInt(res[0]) > y && res[1].equals("MutableChildNode")) {
                    MutableChildNode<Integer> child = new MutableChildNode<>(Integer.parseInt(res[2]));
                    AddChild(child);
                } else throw new Exception("Wrong Format");
                y = Integer.parseInt(res[0]);
            }
            return (MutableRootNode<T>) root;
        }
        catch (Exception e)
        {
            throw new ExceptionInInitializerError("Wrong format");
        }
    }

    /**
     * Parse string to double tree.
     * @param input tree in string
     * @return root node
     * @see TreeImporter#importStringMutableTree(String)
     * @see TreeImporter#importIntegerMutableTree(String)
     */
    public static <T> MutableRootNode<T> importDoubleMutableTree(String input) {
        String[] strs = input.split("\n");
        MutableRootNode<Double> root = null;
        int y = 0;
        try {
            for (String str : strs) {
                String[] res = Parse(str.toCharArray());
                if (Integer.parseInt(res[0]) == 0 && res[1].equals("MutableRootNode")) {
                    root = new MutableRootNode<>(Double.parseDouble(res[2]));
                    stack.push(root);
                } else if (Integer.parseInt(res[0]) <= y && res[1].equals("MutableParentNode")) {
                    MutableParentNode<Double> par = new MutableParentNode<>(Double.parseDouble(res[2]));
                    stack.pop();
                    AddChild(par);
                    stack.push(par);
                } else if (Integer.parseInt(res[0]) > y && res[1].equals("MutableParentNode")) {
                    MutableParentNode<Double> par = new MutableParentNode<>(Double.parseDouble(res[2]));
                    AddChild(par);
                    stack.push(par);
                } else if (Integer.parseInt(res[0]) <= y && res[1].equals("MutableChildNode")) {
                    MutableChildNode<Double> child = new MutableChildNode<>(Double.parseDouble(res[2]));
                    stack.pop();
                    AddChild(child);
                } else if (Integer.parseInt(res[0]) > y && res[1].equals("MutableChildNode")) {
                    MutableChildNode<Double> child = new MutableChildNode<>(Double.parseDouble(res[2]));
                    AddChild(child);
                } else throw new Exception("Wrong Format");
                y = Integer.parseInt(res[0]);
            }
            return (MutableRootNode<T>) root;
        }
        catch (Exception e)
        {
            throw new ExceptionInInitializerError("Wrong format");
        }
    }

    /** Parse char array to indent, type and value.
     * @param str char array for parse
     * @return array of three strings: number of indents, type and value
     */
    private static String[] Parse(char[] str){
        int j = 0;
        boolean f = true;
        String type = "";
        String val = "";
        for (char c : str) {
            if (c == '(')
                f = false;
            if (c == ' ')
                ++j;
            else if (f)
                type += c;
            else if (c != '(' && c != ')')
                val += c;
        }
        return new String[] {Integer.toString(j), type, val};
    }

    /** Add child for node in {@link TreeImporter#stack}
     * @param node child
     */
    private static <T> void AddChild(AbstractTreeNode<T> node)
    {
        AbstractTreeNode<T> treeNode = stack.peek();
        if (treeNode instanceof MutableParentNode)
            ((MutableParentNode<T>) treeNode).addChild(node);
        else if (treeNode instanceof MutableRootNode)
            ((MutableRootNode<T>) treeNode).addChild(node);
        if (node instanceof MutableChildNode)
            ((MutableChildNode<T>) node).setParent((IParent<T>) treeNode);
        if (node instanceof MutableParentNode)
            ((MutableParentNode<T>) node).setParent((IParent<T>) treeNode);

    }
}
