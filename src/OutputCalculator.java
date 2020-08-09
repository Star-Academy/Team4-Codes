import java.util.*;
public class OutputCalculator {
    ArrayList<String> shouldBe;
    ArrayList<String> mustBe;
    ArrayList<String> mustNotToBe;
    Set<String> output;
    InvertedIndex allTokens;

    //init defaults
    OutputCalculator(InvertedIndex allTokens){
        shouldBe = new ArrayList<>();
        mustBe = new ArrayList<>();
        mustNotToBe = new ArrayList<>();
        output = new HashSet<>();
        this.allTokens = allTokens;
    }

    //pre processing for calculating
    private void processKeywords(String[] keywords){
        for (String keyword : keywords) {
            if (keyword.startsWith("+")) { //plus sign handled
                shouldBe.add(keyword.substring(1));
            } else if (keyword.startsWith("-")) { //minus sign handled
                mustNotToBe.add(keyword.substring(1));
            } else { //no sign handled
                mustBe.add(keyword);
            }
        }
    }

    //check if toke's map contains the keyword
    private boolean isContainKey (String keyword, InvertedIndex allTokens){
        return allTokens.getTokens().containsKey(keyword);
    }

    public Set<String> returnOutput(String[] keywords){

        processKeywords(keywords);

        noSignHandling();

        plusSignHandling();

        minusSignHandling();

        return output;
    }

    private void noSignHandling(){
        boolean isFirstTime = true;
        for (String keyword : mustBe) {
            if (isContainKey(keyword, allTokens)) {
                if (!isFirstTime) { //if it's firs time we just add it after that gonna retain it all
                    output.retainAll(allTokens.getTokens().get(keyword)); //retaining
                } else {
                    output.addAll(allTokens.getTokens().get(keyword));
                    isFirstTime = false;
                }
            }
        }
    }
    private void plusSignHandling(){
        for (String keyword : shouldBe) {
            if (isContainKey(keyword, allTokens)) {
                output.addAll(allTokens.getTokens().get(keyword)); //adding to output
            }
        }
    }
    private void minusSignHandling(){
        for (String keyword : mustNotToBe) {
            if (isContainKey(keyword, allTokens)) {
                output.removeAll(allTokens.getTokens().get(keyword)); //removing from output
            }
        }
    }

}
