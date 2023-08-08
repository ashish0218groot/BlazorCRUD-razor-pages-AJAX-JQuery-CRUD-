window.SuperHeroesServiceInterop = {
    navigateToHero: function (id) {
        if (id === null) {
            window.location.href = "/hero";
        } else {
            window.location.href = `/hero/${id}`;
        }
    },
    getAllSuperHeroes: async () => {
        const response = await fetch('/api/SuperHero');
        if (response.ok) {
            const data = await response.json();
            console.log('Data', data);
            return data;
        } else {
            console.log('Data', response.statusText);

            throw new Error(response.statusText);
        }
    },
    getSingleSuperHero: function (id, callback) {
        fetch(`/api/SuperHero/${id}`)
            .then(response => response.json())
            .then(data => callback(data));
    },
    createSuperHero: function (superHero, callback) {
        fetch('/api/SuperHero', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(superHero)
        })
            .then(response => response.json())
            .then(data => callback(data));
    },
    updateSuperHero: function (superHero, callback) {
        fetch(`/api/SuperHero/${superHero.Id}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(superHero)
        })
            .then(response => response.json())
            .then(data => callback(data));
    },
    deleteSuperHero: function (id, callback) {
        fetch(`/api/SuperHero/${id}`, {
            method: 'DELETE'
        })
            .then(response => response.json())
            .then(data => callback(data));
    },
    getAllComics: function (callback) {
        fetch('/api/Comic')
            .then(response => response.json())
            .then(data => callback(data));
    }
};

//window.SuperHeroesServiceInterop = {
//    navigateToHero: function (id) {
//        if (id === null) {
//            window.location.href = "/hero";
//        } else {
//            window.location.href = `/hero/${id}`;
//        }
//    },
//    getAllSuperHeroes: function (callback) {

//        JQuery.ajax({
//            url: '/api/GetSuperHeroes',
//            type: 'GET',
//            success: function (data) {
//                callback(data);
//            },
//            error: function (error) {
//                console.log('Error fetching SuperHeroes', error);
//            }
//        });
//    },
//    getSingleSuperHero: function (id, callback) {
//        $.ajax({
//            url: `/api/SuperHero/${id}`,
//            type: 'GET',
//            success: function (data) {
//                callback(data);
//            },
//            error: function (error) {
//                console.log(`Error fetching SuperHero with ID:`, error);
//            }
//        });
//    },
//    createSuperHero: function (superHero, callback) {
//        $.ajax({
//            url: '/api/SuperHero',
//            type: 'POST',
//            contentType: 'application/json',
//            data: JSON.stringify(superHero),
//            success: function (data) {
//                callback(data);
//            },
//            error: function (error) {
//                console.log('Error creating SuperHero', error);
//            }
//        });
//    },
//    updateSuperHero: function (superHero, callback) {
//        $.ajax({
//            url: `/api/SuperHero/${superHero.Id}`,
//            type: 'PUT',
//            contentType: 'application/json',
//            data: JSON.stringify(superHero),
//            success: function (data) {
//                callback(data);
//            },
//            error: function (error) {
//                console.log('Error updating SuperHero', error);
//            }
//        });
//    },
//    deleteSuperHero: function (id, callback) {
//        $.ajax({
//            url: `/api/SuperHero/${id}`,
//            type: 'DELETE',
//            success: function (data) {
//                callback(data);
//            },
//            error: function (error) {
//                console.log(`Error deleting SuperHero with ID ${id}:`, error);
//            }
//        });
//    },
//    getAllComics: function (callback) {
//        $.ajax({
//            url: '/api/Comic',
//            type: 'GET',
//            success: function (data) {
//                callback(data);
//            },
//            error: function (error) {
//                console.log('Error fetching Comics', error);
//            }
//        });
//    }
//};
