import java.io.File;
import java.util.HashMap;
import java.util.Map;
import java.util.Set;

public class InvertedIndex{
    Map<String, Set<String>> tokens;
    public InvertedIndex(){
        tokens = new HashMap<>();
    }

    public Map<String, Set<String>> getTokens() {
        return tokens;
    }

    public void fillMap(){
        File dir = new File("C:\\EnglishData");
        File[] directoryListing = dir.listFiles();
        if (directoryListing != null) {
            for (File child : directoryListing) {
                if (child.length() != 0) {
                    FileRead fr = new FileRead(child);
                    fr.goThroughFile();
                }
            }
        }
    }
}