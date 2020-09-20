package roughset;

import java.util.ArrayList;

public class RoughSetFactory {
    
    // tra ve tap thuoc tinh
    public static ArrayList<Integer> createAttributeSet(int[] values) {
        ArrayList<Integer> result = new ArrayList<>();
        for(int i = 0; i < values.length; ++i) 
            result.add(values[i]);
        return result;
    }
}
