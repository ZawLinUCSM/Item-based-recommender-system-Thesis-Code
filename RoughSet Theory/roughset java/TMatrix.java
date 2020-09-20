package roughset;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map.Entry;

// ma tran phan biet
public class TMatrix {
    
    // he thong tin T=(U,A)
    Table _table;
    
    // tap thuoc tinh
    ArrayList<Integer> _setB;
    
    // ma tran phan biet doi xung n x n voi n = _table.size()
    ArrayList[][] _elements;
    
    // dem so lan xuat hien cua cac thuoc tinh
    // _countAttributes[1] = 3: thuoc tinh 1 xuat hien 3 lan
    HashMap<Integer, Integer> _countAttributes;
    
    // tap thuoc tinh rut gon tu [_setB]
    ArrayList<Integer> _compactAttrSet;
    
    // dai dien cho phan hoach 
    IND _ind;
    
    // ma tran phan biet tuong ung voi he thong tin T=(U,A)
    public TMatrix(Table table, ArrayList<Integer> setB) {
        _table = table;
        _setB = setB;
        _ind = new IND(_table, setB);
        _elements = new ArrayList[_table.size()][_table.size()];
        _countAttributes = new HashMap<>();
        
        // initialize the _countAttributes
        for(int i = 0; i < _setB.size(); ++i) {
            _countAttributes.put(_setB.get(i), 0);
        }        
        
        buildMatrix();
    }
    
    // xay dung ma tran phan biet :v
    private void buildMatrix() {
        for(int i = 0; i < _table.size()-1; ++i) {
            for(int j = i + 1; j < _table.size(); ++j) {
                _elements[i][j] = funcDistinguishAttributes(i, j);
            }
        }
    }
    
    // dung cho muc dich debug
    public void printMatrix() {
        for(int i = 0; i < _table.size()-1; ++i) {
            for(int j = i + 1; j < _table.size(); ++j) {
                System.out.printf("for d(%d,%d): %s\n", i, j, _elements[i][j]);
            }
        }
    }
    
    // for debug
    public void printCountAttributes() {
        _countAttributes.keySet().stream().forEach((key) -> {
            System.out.printf("k[%d]=%d\n", key, _countAttributes.get(key));
        });
    }
    
    // tra ve danh sach cac thuoc tinh phan biet cua 2 doi tuong x[i] va x[j]
    // tra ve null neu khong co thuoc tinh phan biet nao
    @SuppressWarnings("unchecked")
    private ArrayList funcDistinguishAttributes(int i, int j) {
        ArrayList result = new ArrayList();
        for(int k = 0; k < _setB.size(); ++k) {
            int index = _setB.get(k);
            Row rowI = _table.get(i);
            Row rowJ = _table.get(j);
            if (!rowI.get(index).equals(rowJ.get(index))) {
                result.add(index);
                int oldValue = _countAttributes.get(index);
                _countAttributes.replace(index, oldValue + 1);
            }
        }        
        return (!result.isEmpty())? result: null;
    }
    
    // tra ve mot tap rut gon cua B (_setB)
    // tra ve NULL neu khong ton tai tap rut gon
    public ArrayList<Integer> getCompactAttrSet() {
        if (!_ind.hasCompact()) {
            // khong ton tai tap rut gon vi khong co thuoc tinh co the bo duoc (thuoc tinh du thua)
            return null;
        }
        if (_compactAttrSet == null) {
            _compactAttrSet = new ArrayList<>();
            
            // ta chi dung lai khi toan bo phan tu cua ma tran la rong
            while(!isNone()){
                Entry<Integer, Integer> entry = getMaxCountAttrEntry();         
                Integer keySelect = entry.getKey();
                                
                // xoa thuoc tinh do khoi danh sach thuoc tinh
                _countAttributes.remove(keySelect);                
                
                // lua chon thuoc tinh xuat hien nhieu nhat cho vao tap rut gon
                _compactAttrSet.add(keySelect);
                
                // chuyen nhung phan tu co chua thuoc tinh do thanh tap rong
                setNone(keySelect);
            }
        }
        return _compactAttrSet;
    }
    
    // kiem tra toan bo phan tu cua ma tran co la rong khong?
    // neu x[i,j] = null tuc la rong
    // tra ve true neu tat ca x[i,j] deu rong
    private boolean isNone() {
        for(int i = 0; i < _table.size() - 1; ++i) {
            for(int j = i + 1; j < _table.size(); ++j) {
                if (_elements[i][j] != null) 
                    return false;
            }
        }
        return true;
    }       
    
    // set tat ca cac phan tu x[i,j] trong ma tran bang rong neu no chua thuoc tinh index
    private void setNone(int index) {
        for(int i = 0; i < _table.size() - 1; ++i) {
            for(int j = i + 1; j < _table.size(); ++j) {
                if (_elements[i][j] != null && _elements[i][j].contains(index)) {
                    _elements[i][j] = null;
                }
            }
        }
    }
    
    // tra ve Entry co value lon nhat trong _countAttributes;
    private synchronized Entry<Integer, Integer> getMaxCountAttrEntry() {        
        Entry<Integer, Integer> result = null;
        for(Entry<Integer, Integer> entry: _countAttributes.entrySet()) {
            if (result == null || entry.getValue().compareTo(result.getValue()) >= 0) {
                result = entry;
            }
        }
        return result;
    }          
}