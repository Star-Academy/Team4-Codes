import java.util.*;

public class Main {

    Set<String> output;
    UserInputProcessor userInputProcessor;
    DirectoryReader directoryReader;
    InvertedIndex invertedIndex;

    public Main(){
        this.output = new HashSet<>();
        userInputProcessor = new UserInputProcessor();
        invertedIndex = new InvertedIndex();
        directoryReader = new DirectoryReader(invertedIndex);
    }

    String output(Set<String> output){
        String result = "";
        if (output.size() != 0) {
            for (String a : output) {
                result = result.concat(a + " ");
            }
        } else {
            result = result.concat("no result found");
        }
        return result;
    }

    public void activityContent(){
        directoryReader.goInFolder();
        String[] keywords = userInputProcessor.inputFromUser();
        OutputCalculator co = new OutputCalculator(invertedIndex);
        output = co.returnOutput(keywords);
        System.out.println(output(output));
    }

    public static void main(String[] args) {
        Main main = new Main();
        main.activityContent();
    }
}
