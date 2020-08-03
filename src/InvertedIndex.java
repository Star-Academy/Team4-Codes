import java.io.File;
import java.util.HashMap;
import java.util.Map;
import java.util.Set;

public class InvertedIndex{
    Map<String, Set<String>> tokens; //our storing map
    public InvertedIndex(){
        tokens = new HashMap<>();
    }

    public Map<String, Set<String>> getTokens() {
        return tokens;
    }

    public void fillMap(){ //read all files from their respective directories
        File dir = new File("C:\\EnglishData");
        File[] directoryListing = dir.listFiles();
        if (directoryListing != null) { //empty directory handling
            for (File child : directoryListing) {
                if (child.length() != 0) { //empty file handling
                    //read the files put all of their words in the list
                    FileRead fr = new FileRead(child);
                    fr.goThroughFile(this);
                }
            }
        }
    }
}