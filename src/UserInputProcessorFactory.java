public class UserInputProcessorFactory {
    String type;
    UserInputProcessor userInputProcessor = null;
    UserInputProcessorFactory(String type){
        this.type = type;
        if (type.equals("code")) userInputProcessor = new UserInputProcessor();
    }

    String[] inputFromUser(){
        return userInputProcessor.inputFromUser();
    }

    String[] inputFromUser(String[] strings){
        return strings;
    }

}
