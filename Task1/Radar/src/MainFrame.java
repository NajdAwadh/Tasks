import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.*;

import javax.swing.*;
import javax.swing.border.Border;
import javax.swing.border.EtchedBorder;
import javax.swing.border.TitledBorder;

public class MainFrame extends JFrame implements ActionListener {
     JButton loadButton; 
      JTextField  fileNamefield ;
      JTextField IDfield ;
      JTextField Timefield ;
      JTextField Azimuthfield ;
      JTextField Elevationfield ;
      JTextField Rangefield ;
      
    public void initialize(){


setTitle("Form1");
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLayout(null);
        //setting the bounds for the JFrame
        setBounds(100,100,645,470);
        Border br = BorderFactory.createLineBorder( Color.GRAY);
        Container c=getContentPane();
        //create load border
        TitledBorder loadBorder = new TitledBorder("Load File");
        loadBorder.setTitleJustification(TitledBorder.LEFT);
        loadBorder.setTitlePosition(TitledBorder.TOP); 
        loadBorder.setTitleFont(new Font("Arial", Font.PLAIN, 10));

        //create display border
        TitledBorder displayBorder = new TitledBorder("File Content");
        displayBorder.setTitleJustification(TitledBorder.LEFT);
        displayBorder.setTitlePosition(TitledBorder.TOP); 
        displayBorder.setTitleFont(new Font("Arial", Font.PLAIN, 10));
         
        //Creating a JPanel for the JFrame
        JPanel loadPanel=new JPanel();
        loadPanel.setBorder(loadBorder);
        
        JPanel displayPanel=new JPanel();
        displayPanel.setBorder(displayBorder);
        
        loadPanel.setLayout(null);

        displayPanel.setLayout(null);

        //-----
        loadButton = new JButton("Load File");
        loadButton.setFocusable(false);
        loadButton.addActionListener(this);
        loadButton.setBackground( Color.WHITE );
       // loadButton.setFontSize( );
        loadButton.setBorder(new RoundedBorder(10));
        loadButton.setFont(new Font("Arial", Font.PLAIN, 10)); 
    

        JLabel fileName = new JLabel("File Name") ;
        fileName.setFont(new Font("Arial", Font.PLAIN, 12));
        fileNamefield = new JTextField();
       //fileNamefield.setBorder(BorderFactory.createEtchedBorder(EtchedBorder.LOWERED));
       fileNamefield.setEditable(false); 

       JLabel Id = new JLabel("ID:") ;
        Id.setFont(new Font("Arial", Font.PLAIN, 12));

       //JTextField 
       IDfield = new JTextField();
       IDfield.setEditable(false);
       
       JLabel Time = new JLabel("Time Stamp:") ;
       Time.setFont(new Font("Arial", Font.PLAIN, 12));

       //JTextField
       Timefield = new JTextField();
       Timefield.setEditable(false);
       
       JLabel Azimuth = new JLabel("Azimuth:") ;
       Azimuth.setFont(new Font("Arial", Font.PLAIN, 12));

       //JTextField
        Azimuthfield = new JTextField();
       Azimuthfield.setEditable(false);

       JLabel Elevation = new JLabel("Elevation:") ;
       Elevation.setFont(new Font("Arial", Font.PLAIN, 12));

       //JTextField 
       Elevationfield = new JTextField();
       Elevationfield.setEditable(false);

       JLabel Range = new JLabel("Range:") ;
       Range.setFont(new Font("Arial", Font.PLAIN, 12));

       //JTextField 
       Rangefield = new JTextField();
       Rangefield.setEditable(false);
//----------

        fileName.setBounds(40,120,100,30);
        loadButton.setBounds(40,30,80,30);
        fileNamefield.setBounds(110,120,150,30);


        Id.setBounds(20,12,100,30);
        IDfield.setBounds(130,20,150,20);

        Time.setBounds(20,30,100,30);
        Timefield.setBounds(130,40,150,20);

        Azimuth.setBounds(20,50,100,30);
        Azimuthfield.setBounds(130,60,150,20);

        Elevation.setBounds(20,70,100,30);
        Elevationfield.setBounds(130,80,150,20);

        Range.setBounds(20,90,100,30);
        Rangefield.setBounds(130,100,150,20);



        loadPanel.add(loadButton ); 
        loadPanel.add(fileName);
        loadPanel.add(fileNamefield);
    
        
    
        displayPanel.add(Id );
        displayPanel.add(IDfield );
        displayPanel.add(Time );
        displayPanel.add(Timefield );
        displayPanel.add(Azimuth );
        displayPanel.add(Azimuthfield );
        displayPanel.add(Elevation );
        displayPanel.add(Elevationfield );
        displayPanel.add(Range );
        displayPanel.add(Rangefield );
        
    
        
        loadPanel.setBounds(100,10,300,200);
        
        displayPanel.setBounds(100,220,300,200);
     
        
      
        
       
        //adding the panel to the Container of the JFrame
        c.add(loadPanel);
        c.add(displayPanel);

        setVisible(true);

    }

    @Override
    public void actionPerformed(ActionEvent event) {

        if(event.getSource()==loadButton){
            JFileChooser file_load = new JFileChooser();
            int res = file_load.showOpenDialog(null);
            if (res== JFileChooser.APPROVE_OPTION){
                File file_path = new File(file_load.getSelectedFile().getAbsolutePath());
                String name = file_path.toString() ;
                fileNamefield.setText(name);
                //System.out.println(file_path);
                //System.out.println(name);
                //
                FileReadingExample(name);
            }
        }
    }
    

   public void FileReadingExample (String filePath){
    try {
            FileReader fileReader = new FileReader(filePath);

            BufferedReader bufferedReader = new BufferedReader(fileReader);

            String line;
            while ((line = bufferedReader.readLine()) != null) {
                String[] values = line.split(",");
                     IDfield.setText(values[0]); 
       Timefield.setText(values[1]); 
       Azimuthfield.setText(values[2]); 
       Elevationfield.setText(values[3]); 
       Rangefield.setText(values[4]);

        

            bufferedReader.close();
            fileReader.close();
        }
    } catch (IOException e) {
            e.printStackTrace();
        }
}
private static class RoundedBorder implements Border {

    private int radius;


    RoundedBorder(int radius) {
        this.radius = radius;
    }


    public Insets getBorderInsets(Component c) {
        return new Insets(this.radius+1, this.radius+1, this.radius+2, this.radius);
    }


    public boolean isBorderOpaque() {
        return true;
    }


    public void paintBorder(Component c, Graphics g, int x, int y, int width, int height) {
        g.drawRoundRect(x, y, width-1, height-1, radius, radius);
    }
}
}


