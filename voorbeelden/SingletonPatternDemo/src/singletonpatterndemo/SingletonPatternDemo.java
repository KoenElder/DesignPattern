/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package singletonpatterndemo;

/**
 *
 * @author karel
 */
public class SingletonPatternDemo {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        //Compile Time Error: The constructor SingleObject() is not visible
        //SingleObject object = new SingleObject();

        //Get the only object available
        SingleObject object = SingleObject.getInstance();
        SingleObject object2 = SingleObject.getInstance();

        //show the message
        object.showMessage();
        object2.showMessage();
    }
}
