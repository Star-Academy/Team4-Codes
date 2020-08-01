import java.io.File;
import java.io.FileNotFoundException;
import java.util.HashSet;
import java.util.Scanner;
import java.util.Set;

public class FileRead {
    File file;
    int docID;
    static int idCounter = 0;
    public FileRead(String path){
        file = new File(path);
        idCounter ++;
        docID = idCounter;
    }
    public boolean containsWord(String word){
        try {
            Scanner fileScan = new Scanner(file);
            String line = fileScan.next();
            line = line.toLowerCase();
            while (fileScan.hasNext()){
                if (line.equals(word))
                    return true;
                line = fileScan.next();
                line = line.toLowerCase();
            }
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        }

        return false;
    }

    public int getDocID() {
        return docID;
    }

    public void goThroughFile(){
        try {
            Scanner fileScan = new Scanner(file);
            String line = fileScan.next();
            line = line.toLowerCase();
            while (fileScan.hasNext()){
                if (Main.invertedIndex.containsKey(line)){
                    Main.invertedIndex.get(line).add(docID);
                } else {
                    Set<Integer> set = new HashSet<>();
                    set.add(docID);
                    Main.invertedIndex.put(line, set);
                }
            }
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        }
    }
}
