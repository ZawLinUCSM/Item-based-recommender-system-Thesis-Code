package roughset;

import java.io.File;
import java.io.BufferedReader;
import java.io.FileReader;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.util.StringTokenizer;
import java.util.ArrayList;
import javax.swing.JOptionPane;

// cac thao tac i/o
public class IOUtils {
    
    // doc file text va convert sang Table
    @SuppressWarnings("unchecked")
    public static Table readTableFromFile(File file) throws IOException {
        Row column = null;        
        Table result = null;
        try {
            BufferedReader fread = new BufferedReader(new FileReader(file));
            String line;
            while((line = fread.readLine()) != null) {
                line = line.trim();
                if (column == null) {
                    if (!line.contains("//") && line.length() != 0) { 
                        column = stringToRow(line);
                        result = new Table(column);
                    }
                } else {
                    if (result == null) {
                        javax.swing.JOptionPane.showMessageDialog(null,
                                "Error to parse file",
                                "Error",
                                JOptionPane.ERROR_MESSAGE
                            );
                        System.exit(1);
                    }
                    if (!line.contains("//") && line.length() != 0) {
                        result.addRow(stringToRow(line));
                    }
                }
            }
            return result;
        } catch(FileNotFoundException e) {
            javax.swing.JOptionPane.showMessageDialog(null,
                        file.getAbsolutePath() + " not found",
                        "Error",
                        javax.swing.JOptionPane.ERROR_MESSAGE
                    );
            return null;
        }
    }
    
    // phai kiem tra dau vao thu cong
    // ham chuyen 1 chuoi sang 1 doi tuong Row
    @SuppressWarnings("unchecked")
    private static Row stringToRow(String msg) {
        StringTokenizer tokenizer = new StringTokenizer(msg, ",");
        ArrayList tokens = new ArrayList();
        while(tokenizer.hasMoreElements()) {
            tokens.add(tokenizer.nextElement());
        }
        return new Row(tokens.toArray());
    }
}
