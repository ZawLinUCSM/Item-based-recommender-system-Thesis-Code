package roughset;

import java.util.ArrayList;

public class EquivalentClassDetector {
    
    // he thong tin
    Table _table;
    
    // tap thuoc tinh
    ArrayList<Integer> _propertiesSet;    
        
    public EquivalentClassDetector(Table table, ArrayList<Integer> propertiesSet) {
        _table = table.copy();
        _propertiesSet = propertiesSet;
    }
    
    // tra ve true neu co the tim thay lop tuong duong
    public boolean hasNext() {
        return !_table.isEmpty();
    }
    
    // tra ve lop tuong duong
    public ArrayList<Integer> next() {
        ArrayList<Integer> result = new ArrayList<>();
        Row element = _table.get(0);
        result.add(element.getId());
        ArrayList<Integer> needsToRemove = new ArrayList<>();
        needsToRemove.add(0);
        for(int i = 1; i < _table.size(); ++i) {           
            Row current = _table.get(i);
            if (Row.isSame(element, current, _propertiesSet)) {
                result.add(current.getId());
                needsToRemove.add(i);
            }
        }
        for(int i = needsToRemove.size() - 1; i>= 0; --i) {
            _table.remove(needsToRemove.get(i));         
        }
        return result;
    }                
    
    // kiem tra lop tuong duong co thuoc tap X?    
    public boolean belongToSetX(ArrayList<Integer> equivalentClass, java.util.Map<Integer, Object> setX) {
        for(int i = 0; i < equivalentClass.size(); ++i) {
            Row currentRow = _table.get(equivalentClass.get(i));
            if (!currentRow.belongToSetX(setX)) {
                return false;
            }
        }
        return true;        
    }
}