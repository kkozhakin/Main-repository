package sample_0.block_local;

public class BlockLocalClassSample {

    interface MyInterface {
        float calculateProduct(float f);
    }


    private boolean isPermitted = false;

    private void setPermitted(boolean v){
        isPermitted = v;
    }

    private MyInterface getMyInterfaceImplementor (float param) {
        if (isPermitted){
            //TODO: note that the class inside one of the blocks of a method:
            class MyInterfaceImpl implements MyInterface {
                private float fValue;
                private MyInterfaceImpl(float initValue){
                    fValue = initValue;
                }
                @Override
                public float calculateProduct(float f) {
                    return fValue * f;
                }
            }
            return new MyInterfaceImpl(param);
        } else {
            return null;
        }
    }

    public static void main(String[] args){
        BlockLocalClassSample instance = new BlockLocalClassSample();

        instance.setPermitted(args.length == 0);

        MyInterface myInterfaceImpl = instance.getMyInterfaceImplementor((args.length == 0)? 7F : 1F);
        if (myInterfaceImpl != null){
            float result = myInterfaceImpl.calculateProduct(5F);
            System.out.println("result = " + result);
        }
    }

}
