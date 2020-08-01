import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;

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
}
