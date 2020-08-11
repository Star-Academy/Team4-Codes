import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;
import java.util.Set;

public class InvertedIndex {
    Map<String, Set<String>> tokens; //our storing map

    public InvertedIndex() {
        tokens = new HashMap<>();
    }

    public void updateMap(String wordsInOneFile, String fileName) {
        String[] words = wordsInOneFile.split(" ");
        for (String word : words) {
            if (tokens.containsKey(word)) {
                tokens.get(word).add(fileName);
            } else {
                tokens.put(word, new HashSet<>(){{add(fileName);}});
            }
        }
    }

    public Map<String, Set<String>> getTokens() {
        return tokens;
    }
}
