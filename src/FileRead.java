import java.io.File;
import java.io.FileNotFoundException;
import java.util.HashSet;
import java.util.Scanner;
import java.util.Set;

public class FileRead {
    File file;
    String docID;
    public FileRead(File file){
        this.file = file;
        docID = this.file.getName();
    }

    public void goThroughFile(){
        try {
            Scanner fileScan = new Scanner(file);
            String line = fileScan.next();
            line = line.toLowerCase();
            while (fileScan.hasNext()){
                if (Main.invertedIndex.containsKey(line)){
                    Main.invertedIndex.get(line).addNewDoc(docID);
                } else {
                    Set<String> set = new HashSet<>();
                    set.add(docID);
                    InvertedIndex tokens = new InvertedIndex(set);
                    Main.invertedIndex.put(line, tokens);
                }
                line = fileScan.next();
                line = line.toLowerCase();
            }
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        }
    }
}
