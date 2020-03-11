//
//  ViewController.swift
//  Hello, world!
//
//  Created by Kirill on 19.09.19.
//  Copyright © 2019 HSE. All rights reserved.
//

import UIKit

class ViewController: UIViewController {

    override func viewDidLoad()
    {
        super.viewDidLoad()
        
        let imageView = UIImageView(image: UIImage(named: "background.jpg"))
        imageView.contentMode = .scaleToFill
        self.view.addSubview(imageView)
        
        let label = UILabel(frame: CGRect(x: 0, y: 0, width: 200, height: 40))
        label.font = UIFont.preferredFont(forTextStyle: .footnote).withSize(20)
        label.textColor = .white
        label.center = CGPoint(x: 190, y: 70)
        label.textAlignment = .center
        label.text = "Hello, world!"

        self.view.addSubview(label)
    }
    
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }


}

