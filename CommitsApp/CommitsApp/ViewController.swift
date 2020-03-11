//
//  ViewController.swift
//  CommitsApp
//
//  Created by Кирилл Кожакин on 02.03.2020.
//  Copyright © 2020 Kozhakin Kirill. All rights reserved.
//

import UIKit
import CoreData

class ViewController: UITableViewController {

    var container: NSPersistentContainer!
    
    override func viewDidLoad() {
        super.viewDidLoad()
        container = NSPersistentContainer(name: "CommitsApp")
        container.loadPersistentStores { storeDescription, error in
            if let error = error {
                print("Unresolved error \(error)")
            }
        }
        performSelector(inBackground: #selector(fetchCommits), with: nil)
    }
    
    func saveContext() {
        if container.viewContext.hasChanges {
            do {
                try container.viewContext.save()
            } catch {
                print("An error occurred while saving: \(error)")
            }
        }
    }

    func fetchCommits() {
        if let data = try? Data(contentsOf: URL(string: "https://api.github.com/repos/apple/swift/commits?per_page=100")!) {
            let jsonCommits = JSON(data: data)
            let jsonCommitArray = jsonCommits.arrayValue
            print("Received \(jsonCommitArray.count) new commits.")
            DispatchQueue.main.async { [unowned self] in
                for jsonCommit in jsonCommitArray {
                    let commit = Commit(context: self.container.viewContext)
                    self.configure(commit, usingJSON: jsonCommit)
                }
                self.saveContext()
            }
        }
        
        sfunc configure(commit: Commit, usingJSON json: JSON) {
        }
    }
}

