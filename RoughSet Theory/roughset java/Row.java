package roughset;

import java.util.ArrayList;

// dai dien cho 1 doi tuong trong he thong tin, tuc la 1 dong trong Table
public class Row {
    
    // data model
    Object[] _items;
            
    int _id;
    
    public Row(final Object[] items) {
        if (items == null || items.length == 0)
            throw new IllegalArgumentException();
        _items = items;
        _id = -1;
    }
    
    // ======== CAC PHUONG THUC QUAN TRONG =======
    // kiem tra xem row1, row2 co la bat kha phan biet tren tap thuoc tinh nao do khong    
    public static boolean isSame(Row row1, Row row2, int[] tapThuocTinh) {
        for(int i = 0; i < tapThuocTinh.length; ++i) {
            int index = tapThuocTinh[i];
            if (!row1.get(index).equals(row2.get(index))) 
                return false;
        }
        return true;
    }
    
    public static boolean isSame(Row row1, Row row2, Integer[] tapThuocTinh) {
        for(int i = 0; i < tapThuocTinh.length; ++i) {
            int index = tapThuocTinh[i];
            if (!row1.get(index).equals(row2.get(index))) 
                return false;
        }
        return true;
    }
    
    public static boolean isSame(Row row1, Row row2, ArrayList<Integer> tapThuocTinh) {
        for(int i = 0; i < tapThuocTinh.size(); ++i) {
            int index = tapThuocTinh.get(i);
            if (!row1.get(index).equals(row2.get(index))) 
                return false;
        }
        return true;        
    }
    
    // kiem tra xem doi tuong co thuoc ve tap X khong? :D   
    public boolean belongToSetX(java.util.Map<Integer, Object> setX) {
        return setX.keySet().stream().noneMatch((i) -> (!_items[i].equals(setX.get(i))));
    }
    
    // sao chep 1 Row
    public Row copy() {
        Object[] obj = new Object[_items.length];
        for(int i = 0; i < obj.length; ++i) {
            obj[i] = _items.clone();
        }
        return new Row(obj);
    }
    
    // dung cho ma tran phan biet
    // tra ve danh sach cac thuoc tinh phan biet cua 2 doi tuong x[i] va x[j]
    @SuppressWarnings("unchecked")
    public ArrayList distinguishAttributes(Row other, ArrayList<Integer> setB) {
        ArrayList result = new ArrayList();
        for(int i = 0; i < setB.size(); ++i) {
            int index = setB.get(i);
            if (!_items[index].equals(other.get(index))) {
                result.add(index);
            }
        }
        return result;
    }
    
    // chuyen Row sang mang cac Object 
    // chu y mang nay bao gom _id cua Row
    public Object[] toArray() {
        Object[] result = new Object[_items.length + 1];
        result[0] = _id;
        for(int i = 0; i < _items.length; ++i) {
            result[i+1] = _items[i];
        }
        return result;
    }
    
    // for debug    
    @Override public String toString() {
        StringBuilder sb = new StringBuilder(String.format("%-5s", (_id != -1)? _id: ""));
        for(int i = 0; i < _items.length; ++i) {
            sb.append(String.format("%-12s ", _items[i]));
        }
        return sb.toString();
    }
    
    // GETTER
    public Object get(int index) { return _items[index]; }    
    public Object[] get() { return _items; }
    public int getId() { return _id; }
    
    // SETTER
    public void set(int index, Object value) { _items[index] = value; }
    public void set(Object[] items) { _items = items; }    
    public void setId(int id) { _id = id; }
}