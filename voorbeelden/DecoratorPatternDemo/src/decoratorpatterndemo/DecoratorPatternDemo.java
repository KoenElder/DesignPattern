/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package decoratorpatterndemo;

/**
 *
 * @author karel
 */
public class DecoratorPatternDemo {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
      Shape circle = new Circle();

      Shape redCircle = new RedShapeDecorator(new Circle());

      Shape redRectangle = new RedShapeDecorator(new Rectangle());
      
      System.out.println("Circle with normal border");
      circle.draw();

      System.out.println("\nCircle with red border");
      redCircle.draw();

      System.out.println("\nRectangle with red border");
      redRectangle.draw();    }
    
}
