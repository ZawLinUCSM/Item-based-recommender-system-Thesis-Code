package roughset;

import java.util.ArrayList;

// dai dien cho phan hoach he thong tin T = (U,A) boi tap thuoc tinh B (tap con cua A)
public class IND {
    
    // he thong tin
    Table _table;
    
    // tap thuoc tinh B (tap con cua A)
    ArrayList<Integer> _setB;
    
    // dung de xac dinh lop tuong duong
    EquivalentClassDetector _equivalentClassDetector;
    
    // bien dung de luu cac lop tuong duong
    ArrayList<ArrayList<Integer>> _equivalentClass;    
       
    // tap cac thuoc tinh khong the bo duoc tren B
    // dung de xac dinh loi (CORE) cua B
    ArrayList<Integer> _coreAttributes;
    
    // thuoc tinh co the bo duoc tren B
    ArrayList<Integer> _removableAttributes;
    
    // dung de luu chuoi ky tu bieu dien cho doi tuong
    String _toString; // cache    
    
    // loi cua B co phai la rut gon hoan toan khong? 
    // CORE(B) = RED(B)?
    Boolean _coreIsRed; 
    
    public IND(final Table table, ArrayList<Integer> setB) {
        _table = table;
        _setB = setB;
        _equivalentClassDetector = new EquivalentClassDetector(_table, _setB);
        _equivalentClass = new ArrayList<>();
        while(_equivalentClassDetector.hasNext()) {
            _equivalentClass.add(_equivalentClassDetector.next());
        }        
    } 

    // kiem tra 2 phan hoach co bang nhau (tuong duong nhau) khong?
    public boolean equivalentTo(IND idn) {
        return toString().equals(idn.toString());
    }
    
    // chuoi mo ta phan hoach co dang [[1,2], [3,4], [5]]
    @Override public String toString() {        
        if (_toString == null) {
            _toString = _equivalentClass.toString();
        }                        
        return _toString;
    }
    
    // tra ve CORE(B)
    public ArrayList<Integer> getCore() {
        if (_coreAttributes == null || _removableAttributes == null) {
            _coreAttributes = new ArrayList<>();
            _removableAttributes = new ArrayList<>();
            for(int i = 0; i < _setB.size(); ++i) {
                ArrayList<Integer> remainingAttrs = new ArrayList<>(_setB);
                remainingAttrs.remove(i);
                IND idnCompare = new IND(_table, remainingAttrs);                
                if (!equivalentTo(idnCompare)) {
                    _coreAttributes.add(i);              
                } else {
                    _removableAttributes.add(i);
                }                       
            }
        }
        return _coreAttributes;
    }
    
    // tra ve tap cac thuoc tinh co the bo duoc tren B
    public ArrayList<Integer> getRemovableAttributes() {
        getCore();
        return _removableAttributes;
    }
    
    // kiem tra xem CORE(B) co la RED(B) khong?
    // chu y rang CORE(B) = giao cua tat ca cac RED(B)
    public boolean coreIsRed() {
        if (_coreIsRed == null) {
            final IND idnCompare = new IND(_table, _coreAttributes);        
            _coreIsRed = equivalentTo(idnCompare);
        } 
        return _coreIsRed;
    } 
    
    // co ton tai tap rut gon cua B khong?
    // khi bo di mot so thuoc tinh co the bo duoc cua B ta duoc 1 rut gon cua B
    public boolean hasCompact() {
        if (_removableAttributes == null) 
            getCore();
        return !_removableAttributes.isEmpty();
    }
}