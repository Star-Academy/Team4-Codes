import java.util.Set;

public class InvertedIndex{
    Set<String> token;
    public InvertedIndex(Set<String> token){
        this.token = token;
    }

    public Set<String> getToken() {
        return token;
    }

    public void addNewDoc(String docName){
        token.add(docName);
    }
}