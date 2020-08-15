storageService = {
    addToLocalStorage: function (item, storageKey) {
        var items = JSON.parse(localStorage.getItem(storageKey))
        if (items == null) {
            items = []
        }
        if (!items.includes(item)) {
            items.push(item);
        }
        localStorage.setItem(storageKey, JSON.stringify(items));
    },
    existsInLocalStorage: function (item, storageKey) {
        var exists = false;
        if (JSON.parse(localStorage.getItem(storageKey)) != null && JSON.parse(localStorage.getItem(storageKey)).includes(item)) {
            exists = true;
        }
        return exists;
    },
    removeFromLocalStorage: function (item, storageKey) {
        var items = JSON.parse(localStorage.getItem(storageKey));
        var filtered = items.filter(x => {
            return x != item;
        })
        localStorage.setItem(storageKey, JSON.stringify(filtered));
    },
    getItems: function (storageKey) {
        var arr = [];
        if (JSON.parse(localStorage.getItem(storageKey)) != null) {
            arr = JSON.parse(localStorage.getItem(storageKey));
        }
        return arr;
    }
}