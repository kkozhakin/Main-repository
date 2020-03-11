//
//  ViewController.swift
//  InTouch
//
//  Created by Kirill on 30.01.20.
//  Copyright © 2020 Kirill Kozhakin. All rights reserved.
//

import UIKit
import MessageUI

class ViewController: UIViewController, MFMessageComposeViewControllerDelegate, MFMailComposeViewControllerDelegate {
    
    @IBAction func sendEmail(_ sender: AnyObject) {
        if MFMailComposeViewController.canSendMail() {
            let mailVC = MFMailComposeViewController()
            mailVC.setSubject("MySubject")
            mailVC.setToRecipients(["kkozhakin@gmail.com"])
            mailVC.setMessageBody("<p>Hello!</p>", isHTML: true)
            mailVC.mailComposeDelegate = self;
            self.present(mailVC, animated: true, completion: nil) } else {
            print("This device is currently unable to send email") }
    }
    @IBAction func sendText(_ sender: AnyObject) {
        if MFMessageComposeViewController.canSendText() {
            let smsVC : MFMessageComposeViewController = MFMessageComposeViewController()
            smsVC.messageComposeDelegate = self
            smsVC.recipients = ["1234500000"]
            smsVC.body = "Please call me back."
            self.present(smsVC, animated: true, completion: nil) } else {
            print("This device is currently unable to send text messages") }
    }
    @IBAction func openWebsite(_ sender: AnyObject) {
    UIApplication.shared.open(URL(string: "http://hse.ru")!, options: [:], completionHandler: nil)
        //In tutorial UIApplication.shared().open(...), but Xcode gave an error (maybe because of the old version Xcode and Swift)
    }
    
    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view, typically from a nib.
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }

    func messageComposeViewController(_ controller: MFMessageComposeViewController, didFinishWith result: MessageComposeResult) {
        switch result {
        case MessageComposeResult.sent:
            print("Result: Text Message Sent!") case MessageComposeResult.cancelled:
                print("Result: Text Message Cancelled.") case MessageComposeResult.failed:
                    print("Result: Error, Unable to Send Text Message.") }
        self.dismiss(animated:true, completion: nil) }

}

