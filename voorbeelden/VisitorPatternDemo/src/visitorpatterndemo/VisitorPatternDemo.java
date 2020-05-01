/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package visitorpatterndemo;

/**
 *
 * @author karel
 */
public class VisitorPatternDemo {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
      ComputerPart computer = new Computer();
      computer.accept(new ComputerPartShowVisitor());    }
    
}
