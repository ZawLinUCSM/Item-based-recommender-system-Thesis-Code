package roughset;

import java.io.File;
import java.io.IOException;
import java.io.Console;

public class Main {
    static Table _table;
    public static void main(String[] args) {
        if (args.length < 2) {
            help();
        }        
        if (!args[0].equalsIgnoreCase("load")) {
            help();
        }
        
        File file = new File(args[1]);
        if (!file.exists()) {
            error("File " + file.getAbsolutePath() + " not found");
        }
        try {
            _table = IOUtils.readTableFromFile(file);
            System.out.println("Table: T = (U,A)");
            _table.print();
            System.out.println("Attribute set A:");
        } catch(IOException e) {                        
            error("Error to read file " + file.getAbsolutePath());
        }
        
        Console console = System.console();
        String line;
        do {
            line = console.readLine("define attribute set B = ");
            line = line.trim();
        } while(!line.equalsIgnoreCase("quit"));
        
    }
    
    public static void help() {
        System.exit(-1);
    }
    
    public static void error(String msg) {
        System.out.println(msg);
        System.exit(-1);
    }
}