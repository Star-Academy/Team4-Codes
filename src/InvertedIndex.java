import java.util.ArrayList;

public class InvertedIndex {
    String key;
    ArrayList<Integer> documentPostings;
    public InvertedIndex(String key){
        this.key = key;
        documentPostings = new ArrayList<>();
    }
    public void addNewPosting(int id){
        documentPostings.add(id);
    }

    @Override
    public String toString() {
        return key + " -> " + documentPostings.toString();
    }
}
