package dir_size.single_thread;

import java.io.File;

// TODO: https://github.com/javacreed/java-fork-join-example

public class DirSize {

    public static long sizeOf(final File file) {
//        System.out.println("Computing size of file {" + file + "} ...");

        long size = 0;
        // Ignore files which are not files and dirs
        if (file.isFile()) {
            size = file.length();
        } else {
            final File[] children = file.listFiles();
            if (children != null) {
                for (final File child : children) {
                    size += DirSize.sizeOf(child);
                }
            }
        }
        return size;
    }
}

class Test {

    public static final File TEST_DIR = new File("C:\\hse\\students");

    public static void main(final String[] args) {
        final long start = System.nanoTime();
        final long size = DirSize.sizeOf(TEST_DIR);
        final long taken = System.nanoTime() - start;
        System.out.println("size = " + size + "; time = " + taken);
//        System.out.println("time = " + TimeUnit.SECONDS.convert(taken, TimeUnit.NANOSECONDS));
    }
}

class TestAverage {
    public static void main(String[] args) {
        long total = 0;
        for (int i = 0; i < 8; i++) {
            long start = System.nanoTime();
            long size = DirSize.sizeOf(Test.TEST_DIR);
            long taken = System.nanoTime() - start;
            total += taken;
            System.out.println("size = " + size + "; time = " + taken);
        }
        System.out.println("total average = " + total / 8); // about 1.5 sec...
    }
}