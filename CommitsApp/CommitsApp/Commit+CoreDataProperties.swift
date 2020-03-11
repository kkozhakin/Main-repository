//
//  Commit+CoreDataProperties.swift
//  CommitsApp
//
//  Created by Кирилл Кожакин on 02.03.2020.
//  Copyright © 2020 Kozhakin Kirill. All rights reserved.
//
//

import Foundation
import CoreData


extension Commit {

    @nonobjc public class func createFetchReques() -> NSFetchRequest<Commit> {
        return NSFetchRequest<Commit>(entityName: "Commit")
    }

    @NSManaged public var date: Date?
    @NSManaged public var message: String?
    @NSManaged public var sha: String?
    @NSManaged public var url: String?

}
