package roughset;

import java.util.ArrayList;

// 1 bang dai dien cho 1 he thong tin T = (U,A)
public class Table {
    
    // tap thuoc tinh A
    Row _columns;
    
    // tap vu tru - tap doi tuong U
    public ArrayList<Row> _rows;    
    
    // thuoc tinh quyet dinh
    //int[] decisiveProperties;
    
    public Table(Row columns) {
        _columns = columns;
        _rows = new ArrayList<>();
    }
    
    public Table(Row columns, ArrayList<Row> rows) {
        this(columns);
        _rows = new ArrayList<>(rows);
    }
    
    // create Table instance from static method
    public Table create(int[] indexs) {
        Table result = new Table(_columns);
        for(int i = 0; i < indexs.length; ++i) {
            result.addRow(_rows.get(indexs[i]));
        }
        return result;
    }
    
    public Table copy() {  
        return new Table(_columns.copy(), _rows);        
    }
    
    // ============== CAC PHUONG THUC QUAN TRONG ==============
    // kiem tra lop tuong duong co thuoc tap X?    
    public boolean belongToSetX(ArrayList<Integer> equivalentClass, java.util.Map<Integer, Object> setX) {
        for(int i = 0; i < equivalentClass.size(); ++i) {
            Row currentRow = _rows.get(equivalentClass.get(i));
            if (!currentRow.belongToSetX(setX)) return false;
        }
        return true;
    }
    
    // kiem tra lop tuong duong co ton tai phan tu thuoc tap X khong? :v    
    public boolean existsItemBelongToSetX(ArrayList<Integer> equivalentClass, java.util.Map<Integer, Object> setX) {
        for(int i = 0; i < equivalentClass.size(); ++i){
            Row currentRow = _rows.get(equivalentClass.get(i));
            if (currentRow.belongToSetX(setX)) {
                return true;
            }
        }
        return false;        
    }
    
    public boolean isEmpty() { return _rows.isEmpty(); }
    
    public void addRow(final Row row) { row.setId(size());_rows.add(row); }    
    
    // dung cho debug
    public void print() {
        System.out.println(_columns);
        for(int i = 0; i < _rows.size(); ++i) {
            System.out.println(_rows.get(i));
        }
    }
    
    public void printAttrs() {
        for(int i = 0; i < _columns.get().length; ++i) {
            System.out.printf("%-5s%-12s\n", i, _columns.get(i));
        }
    }
    
    // GETTER
    public Row getColumn() {
        return _columns;
    }
    
    // tra ve so phan tu cua tap vu tru U   
    public int size() { 
        return _rows.size();
    }    
    
    // tra ve phan tu co chi so [index] trong bang
    public Row get(int index) {
        return _rows.get(index);
    }
       
    // tra ve dong co chi so [index]
    public Row remove(int index) {            
        return _rows.remove(index);        
    }
}
