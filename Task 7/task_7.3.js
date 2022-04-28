class Servie {
    constructor() {
        this.collection = [];
    }

    add(item) {
        this.collection.push(item);
    }

    getById(id) {
        try {
            return this.collection[id];
        } catch (error) {
            console.log("Exception happened while executing getById method.")
            return null;
        }
    }

    getAll() {
        return this.collection;
    }

    deleteById(id) {
        try {
            let tmpObj = this.collection[id];
            this.collection.splice(id, 1);
            return tmpObj;
        } catch (error) {
            console.log("Exception happened while executing deleteById method.")
            return null;
        }
    }

    updateById(id, newItem) {
        try {
            for (var key of Object.keys(newItem)) {
                this.collection[id][key] = newItem[key];
            }
        } catch (error) {
            console.log("Exception happened while executing updateById method.")
            return null;
        }
    }

    replaceById(id, newItem) {
        try {
            this.collection[id] = newItem;
        } catch (error) {
            console.log("Exception happened while executing replaceById method.")
            return null;
        }
    }
}
