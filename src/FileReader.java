import java.io.File;
import java.io.FileNotFoundException;
import java.util.HashSet;
import java.util.Scanner;
import java.util.Set;

public class FileReader {
    File file;
    String docID;
    public FileReader(File file){
        this.file = file;
        docID = this.file.getName(); //store the name of the document as their respective's id
    }

    //read words from files and add them to inverted index map
    public void goThroughFile(InvertedIndex allTokens){
        try {
            //scan file data
            Scanner fileScan = new Scanner(file);

            while (fileScan.hasNext()){
                String line = fileScan.next();
                line = line.toLowerCase();    
                if (allTokens.getTokens().containsKey(line)){ //if inverted index already contains the word
                    allTokens.getTokens().get(line).add(docID);
                } else {
                    //word doesn't exist handling
                    Set<String> set = new HashSet<>();
                    set.add(docID);
                    allTokens.getTokens().put(line,set);
                }
            }
            fileScan.close();
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        }
    }
}
