package sample_3.proxy;

import java.lang.reflect.Proxy;

public class MyProxyTest {

    public static void main(String[] args){

//        System.out.println("MyProxyTest.class.getClassLoader() = " + MyProxyTest.class.getClassLoader());

        MyTestInterface1 p = (MyTestInterface1) Proxy.newProxyInstance(
        MyProxyTest.class.getClassLoader(),
            new Class[]{
                MyTestInterface1.class
                        ,
                MyInterface2.class
            },
            new MyTraceHandler(new MyTestInterface1() {
                @Override
                public Object m1(int i) {
                        System.out.println(this + ".m1(" + i + ") invoked; returning null...");
                    return null;
                }
            })
        );
        p.m1(5);

        Class proxyClass = p.getClass();
        System.out.println("proxyClass.isSynthetic() = " + proxyClass.isSynthetic());
        System.out.println("proxyClass = " + proxyClass + ", proxyClass.getClassLoader() = " + proxyClass.getClassLoader());

    }
}
