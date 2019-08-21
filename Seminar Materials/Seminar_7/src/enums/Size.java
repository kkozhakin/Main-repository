package enums;

public enum Size {
    SMALL ("S") {
        @Override
        public String getAbbreviation() {
            return super.getAbbreviation() + "; I am the smallest size among others...";
        }
        @Override
        boolean isAvailable(){return true;}
    }
    ,
    MEDIUM ("M"){
        @Override
        public String toString(){return super.toString() + "; this is my favorite size...";}
        @Override
        boolean isAvailable(){return true;}
    }
    , LARGE ("L"){
        @Override
        boolean isAvailable(){return false;}

    }, EXTRA_LARGE ("XL"){
        @Override
        boolean isAvailable(){return false;}

    };
    //private
    Size (String abbreviation) {
        this.abbreviation = abbreviation;
    }

    abstract boolean isAvailable(); //TODO: note abstract method in enum ...
    public String getAbbreviation() { return abbreviation; }

    private String abbreviation;

    public static void main(String[] args) {
        for (Size s : Size.values()){
            System.out.println("" + s.ordinal() + ": " + s + ": available = " + s.isAvailable() + "; "+ s.getAbbreviation());
        }
    }
}
