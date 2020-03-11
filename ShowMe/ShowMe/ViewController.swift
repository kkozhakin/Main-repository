//
//  ViewController.swift
//  ShowMe
//
//  Created by Kirill on 22.01.20.
//  Copyright © 2020 Kirill Kozhakin. All rights reserved.
//

import UIKit

class ViewController: UIViewController {
    @IBOutlet weak var textToSendField: UITextField!
    @IBAction func showMe(_ sender: AnyObject) {
        NSLog("User Wrote: %@", textToSendField.text!)
    }

    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view, typically from a nib.
    }
    
    override func prepare(for segue: UIStoryboardSegue, sender: Any?) {
        let messageController = segue.destination as! MessageViewController
        messageController.messageData = textToSendField.text
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }


}

