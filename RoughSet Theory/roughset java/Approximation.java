package roughset;

import java.util.ArrayList;

// Xap xi tren && xap xi duoi duoc tinh bang doi tuong nay
public class Approximation {
    
    // he thong tin
    Table _table;
    
    // dung de xac dinh lop tuong duong
    EquivalentClassDetector _equivalentClassDetector;
    
    // bien dung de luu cac lop tuong duong
    ArrayList<ArrayList<Integer>> _equivalentClass;
    
    // tap X co la tap tho hay khong? :v
    java.util.Map<Integer, Object> _setX;
    
    // tap B la tap cac thuoc tinh ta dung de phan hoach
    ArrayList<Integer> _setB;
        
    public Approximation(Table table, ArrayList<Integer> setB, java.util.Map<Integer, Object> setX) {
        _table = table;
        _setB = setB;
        _setX = setX;
        _equivalentClassDetector = new EquivalentClassDetector(_table, _setB);
        _equivalentClass = new ArrayList<>();
        while(_equivalentClassDetector.hasNext()) {
            _equivalentClass.add(_equivalentClassDetector.next());
        }
    }    
    
    // tra ve xap xi duoi B_(X)
    public ArrayList<Integer> below() {                            
        // bien luu ket qua tap xap xi duoi
        ArrayList<Integer> result = new ArrayList<>();         

        for(int i = 0; i < _equivalentClass.size(); ++i) {
            ArrayList<Integer> equivalentCls = _equivalentClass.get(i);
            if (_table.belongToSetX(equivalentCls, _setX)) {
                result.addAll(equivalentCls);
            }            
        }
        return result;
    }
    
    // tra ve xap xi tren B~(X)
    public ArrayList<Integer> above() {                
        // bien luu ket qua tap xap xi tren
        ArrayList<Integer> result = new ArrayList<>();
        for(int i = 0; i < _equivalentClass.size(); ++i) {
            ArrayList<Integer> equivalentCls = _equivalentClass.get(i);
            if (_table.existsItemBelongToSetX(equivalentCls, _setX)) {
                result.addAll(equivalentCls);
            }
        }                
        return result;
    }
    
    // tap X co la tap tho khong?
    public boolean isRough() {
        ArrayList<Integer> belowSet = below();
        ArrayList<Integer> aboveSet = above();
        return (!belowSet.isEmpty()) && (aboveSet.size() != _table.size());        
    }
}